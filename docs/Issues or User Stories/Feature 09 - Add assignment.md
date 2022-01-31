As a user,
I need to be able to assign work to a student,
So that I can track completion and grades.

Acceptance Criteria:
* When the Student Details menu displays, there is a menu item/option to add an assignment.
* When this menu item is selected, the user is asked to enter the name of a new assignment.
* Once the user enters a name, a new assignment is created and attached to the current student (the student attached to the current instance of the Student Details menu).
* When a new assignment is created, it is not complete/graded. If an ungraded assignment has any grade, it is 0.
* After the assignment is added, the Student Details menu re-displays.

Notes:
* An assignment will be completed when it is graded, and it will be graded when it is completed. The terms "completed" and "graded" can be used interchangeably.
* Each student needs its own collection of assignments.
* Adding an assignment to one student does not add it to any other students.
* Within a given student, each assignment must have a unique name.
* A student can have an assignment with the same name as an assignment from a _different_ student. 
* If John has an assignment named Variables, and Sarah also has an assignment named Variables, the two Variables assignments are separate and can have different property values. Any changes made or methods called for one Variables assignment do not affect the other Variables assignment.
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the add assignment menu option?
    * What happens if the user enters a name that already exists?
        * Display a message telling about the error? And then what? (Ask for a different name, and keep going until the user gets it right? Just go immediately back to the Student Details menu?)
        * Create the new assignment and replace the old one that had the same name? (I would prefer _not_ to do this)
        * Do nothing?
