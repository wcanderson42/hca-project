# HCA Backend Coding Assignment #
by Colten Anderson

## Future Branch
On this branch I will make additions and improvements based on what I would do to continue this project
Ideas
- add an error handler to display validation errors
- delegate database requests so that they are available to other controllers
- delegate validation by type to make validators more readable
- persist ViewData when validation fails

## Assignment ##
1. Creating a sample web app with CRUD & REST operations with UI
2. Implement backend using C# and MVC using ASP.net
3. Implement SQL/Repository using some entity/SQL
4. Any additional common best practices for development
5. Should be shared via GitHub link

## Project Setup ##
(assumes dotnet and git are already installed)
1. clone repository locally
2. Open a terminal at project
3. Install required local tools with `dotnet tool restore`
4. Set up database with `dotnet ef database update`
5. Build and run the project with `dotnet run`
6. Open browser at assigned localhost port 

## Indended Flow ##
1. Add patient(s) via Patients > Create New
2. Add provider(s)via Providers > Create New
3. Add Schedule Slot(s) via ScheduleSlots > Create New
4. Add appoiontment(s) via Appointments > Create New
    - Appointments should fill an open slot with a patient
    - On create, the slot should be marked as not available and not shown for future appointments
    - On delete, the slot should be marked as available again
    - If the slot is deleted the appointment will also be deleted