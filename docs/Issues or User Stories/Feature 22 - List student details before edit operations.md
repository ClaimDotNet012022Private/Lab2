As a user,
I need to be able to see students before I edit them,
So I can decide which student I want to edit.

Acceptance Criteria:
* On the Classroom Details menu, when certain menu items/options are selected, display a list of students before doing anything else (importantly, before asking the user to input a student name).
* The student listing is displayed the same way as when the "Show Students" menu item is displayed.
* When the user is asked to input a student name, the student listing remains visible on the console.
* The menu items that show the list of students include:
    * Show Students (of course, should already be implemented)
    * Compare Students
    * Student Details

Notes:
* Only the menu items listed above are _required_ to show student details, but your implementation _can_ show student details for other menu items it makes sense to do so.
    * Remove Student makes sense because the user must select an existing student. 
    * Add Student _might_ make sense because the user might need to see existing students to avoid re-adding the same one.
    * Average, Top, and Bottom should not display the list of students.
