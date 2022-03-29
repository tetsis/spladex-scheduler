# Splatoon2 Video Index Scheduler
```
                 +---------------+
+----------+     |      +------+ |     +-----+
| Frontend |-----| API  | Core | |-----| RDB |
+----------+     |      + -----+ |     +-----+
                 +---------------+
                         |
              +---------------------+
              |            +------+ |
              | Scheduler  | Core | |
              |            + -----+ |
              +---------------------+
```

- Frontend
    - [Repo](https://github.com/tetsis/splatoon2-video-index-frontend)
    - React
    - Deployed in [vercel](https://vercel.com/)
        - [page](https://splatoon2-video-index.vercel.app)
- API
    - [Repo](https://github.com/tetsis/splatoon2-video-index-api) (private)
    - ASP.NET
- Core
    - [Repo](https://github.com/tetsis/splatoon2-video-index-core)
    - C#
- RDB
    - MySQL
- Scheduler (here)
    - [Repo](https://github.com/tetsis/splatoon2-video-index-scheduler)
    - C#
    - Azure functions