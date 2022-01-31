As a user,
I need to be able to see the average grade for a classroom,
So that I can track how the class as a whole is doing.

Acceptance Criteria:
* The Classroom Details menu includes a menu item/option to show the class average.
* When this menu item is selected, the average grade of all students in the classroom is displayed.
* The average is **not** weighted based on number of assignments. Each student (or at least, each student with a grade) has equal weight. So the class average is the average of all the student averages. Example:
    * The class contains two students, Foo and Bar.
    * Foo has two assignments, both with a grade of 80.
    * Bar has 8 assignments, and all 8 have a grade of 90.
    * Adding all 10 assignments together and dividing by 10 would give a _weighted_ average of 88. This is the wrong result.
    * Since Foo has an average of 80, and Bar has an average of 90, the average of all the students (unweighted) is `(80 + 90) / 2`, which is 85. This is the result you want.
* After the average grade is displayed, the user has a chance to see it (for example, by pausing until the user presses a key), and then the Classroom Details menu is re-displayed.

Notes:
* The way you handle the case where there are no students (or no students with assignments, or no students with graded/completed assignments) should be consistent with the handling for Top Student and Bottom Student.
* Some information may not be specified and is left up to developer interpretation. In a real-world scenario you would want to confirm details with the client (probably through your scrum master or product owner). Examples include:
    * If a student has no assignments (or no graded/completed assignments), do they count toward the total average (with a student average of 0), or are they ignored?
