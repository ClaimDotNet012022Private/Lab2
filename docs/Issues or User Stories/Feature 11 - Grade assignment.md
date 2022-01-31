As a user,
I need to be able to grade an assignment,
So that the grades are available to work with.

Acceptance Criteria:
* When the Student Details menu displays, there is a menu item/option to grade an assignment.
* When this option is selected, the user is asked for the name of an assignment belonging to the current student, as well as for a grade to give.
* The grade is not limited to integers - it can be a decimal value.
* After the user gives the assignment name and grade:
    * The assignment with the given name has its grade set to the given grade.
    * The assignment is now considered complete (or graded).
* After the assignment is updated, the Student Details menu re-displays.

Notes:
* Giving a grade to one assignment does not affect any other assignments.
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the grade assignment menu option?
    * What order does this menu item appear in, in relation to any other menu items (except the exit/return to parent menu option)?
    * What happens if no assignments have been added to the current student?
    * What happens if the user enters a name that doesn't exist (hasn't been added as an assignment for the current student)?
    * What happens if the user enters an invalid grade?
    * What exactly is a valid grade? It must be a decimal value (can be parsed into a double or float), but is there any other validation? Are negative numbers allowed? What about numbers over 100?
