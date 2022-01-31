As a user,
I need to be able to see details of the current student, including name, average grade, number of assignments, and whether or not all assignments have been completed (graded),
So that I have all the information needed to manage a student.

Acceptance Criteria:
* When the Student Details menu displays for a specific student, it includes an option/item to see details or a summary of the current student.
* When the details/summary option is chosen, the student's details are printed.
* After the details are printed, the user has a chance to see the details (perhaps by waiting for the user to press a key), and then the Student Details menu is re-displayed.
* Details include (not necessarily in this order):
    * Student name
    * Average grade of this student's assignments
    * Number of assignments this student has
    * An indication (yes/no, true/false, etc.) of whether or not all of the student's assignments have been completed.

Notes:
* Reminder: An assignment is completed when it is graded.
* Some information has been left unspecified and is up to developer's interpretation. In a real-world scenario, you would want to clarify these with your client:
    * What is the wording of the menu option?
    * What average shows if there are no assignments (or no completed assignments)?
    * Does the average include incomplete assignments (treating their grade as 0.0), or only completed assignments?
    * Are all assignments complete if there are no assignments?
    * What order are the properties printed in?
    * What is the exact wording of the details section?
