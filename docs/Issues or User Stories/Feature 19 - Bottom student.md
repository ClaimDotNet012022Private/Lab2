As a user,
I need to be able to see the bottom student (the student with the lowest average grade) in the classroom,
So that I can see who is performing well.

Acceptance Criteria:
* The Classroom Details menu contains a menu item/option for "Bottom Student" (or "Worst Student" or similar).
* When this menu item is selected, a message is displayed. At minimum, the message contains the name of the student who has the worst average grade in the classroom.
* After the message displays, the user has a chance to see it (for example, by pausing until the user presses a key), and then the Classroom Details menu re-displays.

Notes:
* The student who displays needs to be the one with the worst **average** grade, not the worst grade for any single assignment.
* Some information is unspecified and has been left up to developer interpretation. In a real-world scenario, you would want to clarify these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the wording of the message? Is it just the student's name, or does it include more?
    * What happens if there are no students? Depending on your implementation of average grade, this could extend to:
        * What if there are no students with assignments?
        * What if there are no students with complete/graded assignments?
    * What happens if several students have the same grade? 
        * For simplicity, I'd recommend just showing one student. 
            * Out of all the students who have the bottom grade, pick one arbitrarily. Note: Arbitrarily does not mean randomly, it just means the user doesn't know or care how it's decided.
            * If you just build your algorithm without thinking about the possibility of ties, this is what will happen naturally.
            * This isn't the only option, but it's the easiest.
