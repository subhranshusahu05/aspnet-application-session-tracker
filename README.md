# ASP.NET Application & Session Tracker
A small **ASP.NET WebForms** demo that shows how to use `Global.asax`, `Application` state and `Session` to track:

- **Total users** (since the app started) and  
- **Number of online users** (currently active sessions).

This project is intended for learning how application-level and session-level events work in WebForms.

---

## Features
- Initializes application counters on `Application_Start`.
- Increments total and online user counters in `Session_Start`.
- Decrements online counter in `Session_End`.
- Simple UI (`WebForm1.aspx`) to display current counts and a **Sign Out** button to abandon the session.

---

## Files of interest
- `Global.asax` / `Global.asax.cs`  
  - Contains `Application_Start`, `Session_Start`, `Session_End` handlers and updates `Application["Total_user"]` and `Application["Number_of_online_user"]`.
- `WebForm1.aspx`  
  - UI that displays `Total User` and `Online User` labels and includes a **Sign Out** button.
- `WebForm1.aspx.cs`  
  - Reads application counters and calls `Session.Abandon()` on sign out.

---

## How it works (simple)
1. When the application first starts, counters are set to `0`.  
2. Every new user session triggers `Session_Start`:
   - `Total_user` increases by 1 (total visits since app start).
   - `Number_of_online_user` increases by 1 (active sessions).
3. When a session ends (timeout or `Session.Abandon()`), `Session_End` decreases `Number_of_online_user` by 1.
4. `WebForm1.aspx` reads and displays these `Application` state values.
## Important notes
- `Session_End` only works for **InProc** session mode (default). If your app uses out-of-process sessions (State Server, SQL Server), `Session_End` will not fire.  
- `Application` state is stored in server memory — be careful storing large data here. Use it for small global counters only.  
- Use `Application.Lock()` / `Application.UnLock()` (as in this project) when updating shared `Application` variables to avoid race conditions.
<img width="1920" height="1080" alt="1" src="https://github.com/user-attachments/assets/048f7559-f26a-4b13-b8ef-7f88a2aba9e5" />

