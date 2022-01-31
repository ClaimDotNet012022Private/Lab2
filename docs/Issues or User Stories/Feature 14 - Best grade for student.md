As a user,
I need to be able to show a student's best grade,
So that I can track the student's progress.

Acceptance Criteria:
* On the Student Details menu, there is an option/menu item to show the best grade.
* When the menu item is selected, the current student's highest-graded assignment displays, with the name and grade for the assignment.
* After the best grade displays, the user has an opportunity to read it (for example, by waiting for the user to press a key), and then the Student Details menu displays again.

Notes:
* Any display format is ok, as long as it includes at least the name and grade of the assignment. It is ok to include extra information. 
    * _In my implementation, I'm using the same format as in the Show Assignments list. I'd recommend this approach so you don't have to manage two different ways of printing an assignment._
* Some information has not been specified and is left to the developer's discretion. In a real world scenario, you would want to clarify these points with the client.
    * What is the wording of the menu option?
    * What happens if there are no completed/graded assignments?
    * What happens if there are no assignments (including incomplete/ungraded ones)?
