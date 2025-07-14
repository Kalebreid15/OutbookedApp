# 📅 Outbooked

**Automated Catering Event Syncing from TripleSeat to Outlook**

---

## 🧭 Introduction

In the catering industry, professionals often juggle multiple platforms to manage bookings, clients, and time. A common pain point is the lack of integration between TripleSeat (a catering/event booking tool) and Microsoft Outlook Calendar, requiring manual entry of events.

**Outbooked** solves this by automating the transfer of event data from TripleSeat to Outlook, saving time and reducing errors.

---

## 🎯 Objectives

- Automatically retrieve event data from TripleSeat (or mock API)
- Sync confirmed events with Microsoft Outlook Calendar
- Provide a clear dashboard to view and manage events
- Detect scheduling conflicts and duplicate entries

---

## 🧩 Project Description

Outbooked is a full-stack web application designed to streamline scheduling for catering professionals. It connects to TripleSeat to fetch upcoming event details—such as date, time, client, and location—and displays this data in a dashboard where users can manage and approve events for syncing.

Using the Microsoft Graph API, approved events are added to the user's Outlook calendar.

**Target Audience:** Small catering teams and venue managers who need simplified, reliable calendar integration.

---

## 🛠️ Technologies and Tools

| Category        | Tools                                                              |
|----------------|---------------------------------------------------------------------|
| Backend         | ASP.NET Core (C#), Dapper or Entity Framework Core                 |
| Frontend        | Razor Pages or MVC with Bootstrap                                  |
| Database        | SQL Server or SQLite                                               |
| APIs            | Microsoft Graph API (Outlook calendar), TripleSeat (mocked or real)|
| Authentication  | Microsoft OAuth                                                    |
| Testing         | Postman, xUnit                                                     |
| Design/Docs     | Canva (proposal, wireframes), GitHub (version control)             |

---

## ✨ Features

| Feature              | Description                                     |
|----------------------|-------------------------------------------------|
| Login with Microsoft | Secure OAuth login for calendar access          |
| Dashboard            | View upcoming events from TripleSeat            |
| Sync to Outlook      | Approve and sync events to calendar             |
| Conflict Detection   | Warn users of overlapping bookings              |
| Manual Add/Edit      | Add or edit events within the dashboard         |
| Event Status Tags    | Mark events as Pending, Synced, or Completed    |

---

## 🛠️ Implementation Plan

1. **Set Up Project:** ASP.NET Core + Bootstrap UI  
2. **Build Mock TripleSeat API:** Simulate event data  
3. **Create Dashboard UI:** CRUD for events  
4. **Integrate Outlook API:** Connect with Microsoft Graph  
5. **Add Sync Logic:** Push events to Outlook calendar  
6. **Handle Conflicts:** Validate times before syncing  
7. **Testing & Polishing:** Manual and unit testing  
8. **Deploy:** Use local IIS for hosting (no Azure required)

---

## 🧪 Testing Plan

- Unit testing for sync logic and event CRUD operations  
- Integration testing for Microsoft Graph API interactions  
- Manual testing for time conflict detection  
- Edge case testing: invalid data, duplicates, API failure

---

## 🚀 Deployment

- Hosting on local IIS (for now—no Azure needed)  
- Secure secrets using environment variables  
- Optional: CI/CD through GitHub Actions

---

## ✅ Expected Outcome

Deliver a working web app that:

- Displays upcoming events from TripleSeat  
- Syncs events directly to Outlook calendar  
- Detects conflicts and avoids duplicate bookings  
- Demonstrates full-stack development with real-world API integration

---

## 📌 Conclusion

Outbooked is designed to solve a real-world problem with a clean, functional solution. It automates scheduling, saves time, and minimizes risk of human error. The project showcases full-stack development, API integration, authentication, and UI design—while helping caterers and venue managers operate more efficiently.
