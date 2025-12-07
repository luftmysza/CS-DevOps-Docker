# App Workflow Overview

## 0. Startup / Wiring

On app start:

**Program.cs**
- Loads config (OMDb API key, etc.)
- Registers:
  - `IExternalMovieProvider` → `OmdbClient`
  - `IMovieRepository` → `InMemoryMovieRepository`
  - `MovieService`
- Adds controllers and runs the app

**InMemoryMovieRepository**
- Backed by `ConcurrentDictionary<string, Movie>`
- Starts empty
- Cache is per-process / per-container

At startup, no movies exist — app is an empty proxy.

---

## 1. Get Movie by IMDb ID (Happy Path)

**Request**
GET /api/movies/tt1375666

**Flow**
1. Controller → `MovieService.GetByImdbIdAsync()`
2. Service → `IMovieRepository.GetByImdbIdAsync()`
3. Cache miss → call `IExternalMovieProvider.GetByImdbIdAsync()`
4. `OmdbClient`:
   - Builds URL
   - Sends HTTP request to OMDb
   - Deserializes JSON to `OmdbMovie`
5. Service:
   - Maps `OmdbMovie` → `Movie`
   - Stores in repo
6. Controller returns `200 OK` with JSON

**Next request for same ID**
- Cache hit → no OMDb call

---

## 2. Search by Title

**Request**
GET /api/movies/search?title=Inception

**Flow**
1. Controller → `MovieService.SearchByTitleAsync()`
2. Service checks cache by normalized title
3. If miss:
   - Calls OMDb with `t=Inception`
   - Maps and stores result
4. Returns movie (or list)

IMDb ID should remain the canonical key.

---

## 3. Failure Scenarios

### a) Movie not found
- OMDb returns null
- Service returns null
- Controller returns `404 Not Found`

### b) OMDb down / network error
- If cached → return cached movie
- If not cached → return error
- Controller returns `503` or `500`

Service layer decides behavior; controllers only map to HTTP.

---

## 4. Data Lifetime

- Cache is:
  - In-memory
  - Per container
  - Lost on restart
- This is acceptable for proxy-style caching

To persist later:
- Implement `IMovieRepository` with a real DB
- Swap DI registration
- No workflow changes needed

---

## 5. Workflow Summary

For every request:
- Controller → Service
- Service:
  - Check cache
  - Fetch from OMDb on miss
  - Map to domain model
  - Store for next time
- Controller → HTTP response

