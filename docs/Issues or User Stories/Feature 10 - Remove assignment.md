As a user, I need to be able to remove an assignment from a student,
So that I can handle when an assignment is revoked or was added in error.

Acceptance Criteria:
* When the Student Details menu displays, there is a menu item/option to remove or unassign an assignment.
* When this menu item is selected, the user is asked to enter the name of an existing assignment.
* Once the user enters the name of an assignment that belongs to the current student, the assignment with the given name is removed from the current student.
* After the assignment is removed, the Student Details menu re-displays.

Notes:
* Removing an assignment from one student does not change any other students.
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the remove assignment menu option?
    * What order does this menu item appear in, in relation to any other menu items (except the exit/return to parent menu option)?
    * What happens if no assignments have been added to the current student?
    * What happens if the user enters a name that doesn't exist (hasn't been added as an assignment for the current student)?
