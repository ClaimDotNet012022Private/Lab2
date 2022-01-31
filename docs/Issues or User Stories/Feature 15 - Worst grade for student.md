As a user,
I need to be able to show a student's worst grade,
So that I can track the student's progress.

Acceptance Criteria:
* On the Student Details menu, there is an option/menu item to show the worst grade.
* When the menu item is selected, the current student's lowest-graded assignment displays, with the name and grade for the assignment.
* After the worst grade displays, the user has an opportunity to read it (for example, by waiting for the user to press a key), and then the Student Details menu displays again.

Notes:
* Any display format is ok, as long as it includes at least the name and grade of the assignment. It is ok to include extra information. _In my implementation, I'm using the same format as in the Show Assignments list._
* Some information has not been specified and is left to the developer's discretion. In a real world scenario, you would want to clarify these points with the client.
    * What is the wording of the menu option?
    * Does an incomplete/ungraded assignment count as the lowest grade (with a grade of zero), or do you ignore incomplete assignments?
    * What happens if there are no no assignments?
