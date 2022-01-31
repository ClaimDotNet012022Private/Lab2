As a user,
I need to be able to see assignments before certain operations,
So I can decide which assignment I want to select.

Acceptance Criteria:
* On the Student Details menu, when certain menu items/options are selected, display a list of assignments before doing anything else (importantly, before asking the user to input an assignment name).
* The assignment listing is displayed the same way as when the "Show Assignments" menu item is chosen.
* When the user is asked to input an assignment name, the assignment listing remains visible on the console.
* The menu items that show the list of assignments include:
    * Show Assignments (of course, should already be implemented)
    * Unassign / Remove Assignment
    * Grade Assignment

Notes:
* Only the menu items listed above are _required_ to show assignment details, but your implementation _can_ show assignment details for other menu items it makes sense to do so.
    * Add Asssignment _might_ make sense because the user might need to see existing assignments to avoid re-adding the same one.
    * Show Summary does not make sense because it operates on the current student, not an assignment.
    * Show Best Grade and Show Worst Grade don't make sense because the user doesn't need to choose an assignment
