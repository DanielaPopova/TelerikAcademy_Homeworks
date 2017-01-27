/*jshint esversion: 6*/
function solve() {

    let Course = {
        init: function(title, presentations) {
            validateTitle(title);
            validatePresentations(presentations);

            this.title = title;
            this.presentations = presentations;
            this.students = [];

            return this;
        },
        addStudent: function(name) {

            if (!name) {
                throw new Error('Invalid parameter for student name passed!');
            }

            let bothNames = name.split(' ').filter(name => {
                return name;
            });

            if (bothNames.length !== 2) {
                throw new Error('Parameter must consist of both first and last name!');
            }

            validateName(bothNames[0]);
            validateName(bothNames[1]);

            let id = this.students.length + 1;
            let student = {
                firstName: bothNames[0],
                lastName: bothNames[1],
                id: id,
                homeworks: [],
                examScore: 0,
                finalScore: 0
            };

            this.students.push(student);

            return id;
        },
        getAllStudents: function() {
            //deep copy
            return this.students.map(st => {
                return {
                    firstname: st.firstName,
                    lastname: st.lastName,
                    id: st.id
                };
            });
        },
        submitHomework: function(studentID, homeworkID) {

            validateID(studentID);
            validateID(homeworkID);

            studentID = +studentID;
            homeworkID = +homeworkID;

            if (studentID < 1 || studentID > this.students.length) {
                throw new Error('Invalid student ID!');
            }

            if (homeworkID < 1 || homeworkID > this.presentations.length) {
                throw new Error('Invalid homework ID!');
            }

            let currStudent = this.students[studentID - 1];

            if (currStudent.homeworks.indexOf(homeworkID) === -1) {
                currStudent.homeworks.push(homeworkID);
            }

            return this;
        },
        pushExamResults: function(results) {

            validateExamResults(results);

            for (let i = 0, len = results.length; i < len; i += 1) {
                let currStudentID = results[i].StudentID,
                    currStudentScore = results[i].score;

                validateID(currStudentID);

                if (!Number(currStudentScore) && !isFinite(currStudentScore)) {
                    throw new Error('Student score must be a valid number!');
                }

                currStudentID = +currStudentID;
                currStudentScore = +currStudentScore;

                if (currStudentID < 1 || currStudentID > this.students.length) {
                    throw new Error('Invalid student ID!');
                }

                if (this.students[currStudentID - 1].examScore !== 0) {
                    throw new Error('This student already has a score!');
                }

                this.students[currStudentID - 1].examScore = currStudentScore;
            }

            return this;
        },
        getTopStudents: function() {

              this.students.forEach(student => {
                    let hwScore = student.homeworks.length / this.presentations.length;
                    student.finalScore = (0.75 * student.examScore) + (0.25 * hwScore);
              });

              this.students.sort((st1, st2) => {
                  return st2.finalScore - st1.finalScore;
              });

              let topStudentsCount = 10,
                  topTenStudents = [];

              if (this.students.length < 10) {
                  topStudentsCount = this.students.length;
              }

              for (let i = 0; i < topStudentsCount; i += 1) {
                  let topStudent = {
                      firstName: this.students[i].firstName,
                      lastName: this.students[i].lastName,
                      id: this.students[i].id
                  };

                  topTenStudents.push(topStudent);
              }

              return topTenStudents;
        }
    };

    //Validation functions
    function validateTitle(title) {

        if (!title || typeof title !== 'string') {
            throw new Error('Title must be a non-empty string!');
        }

        if (title[0] === ' ' || title[title.length - 1] === ' ') {
            throw new Error('Title cannot start or end with whitespace!');
        }

        let whitespacesCount = title.trim().split(' ').filter(el => {
            return !el;
        }).length;

        if (whitespacesCount > 0) {
            throw new Error('There cannot be consecutive whitespaces int title!');
        }
    }

    function validatePresentations(presentations) {

        if (!presentations || !Array.isArray(presentations) || presentations.length === 0) {
            throw new Error('Invalid presentations parameter!');
        }

        for (let i = 0, len = presentations.length; i < len; i += 1) {
            validateTitle(presentations[i]);
        }
    }

    function validateName(name) {

        let firstChar = name.charCodeAt(0);

        if (firstChar < 65 || firstChar > 90) {
            throw new Error('Name must start with a capital letter!');
        }

        for (let i = 1, len = name.length; i < len; i += 1) {
            if (name.charCodeAt(i) < 97 || name.charCodeAt(i) > 122) {
                throw new Error('Except first letter, all symbols in name must be lowercase letters!');
            }
        }
    }

    function validateID(id) {

        if (!id) {
            throw new Error('Invalid input for id!');
        }

        if (id % 1 !== 0) {
            throw new Error('Id must be an integer number!');
        }

        if (!Number(id)) {
            throw new Error('Id must be a number!');
        }
    }

    function validateExamResults(results) {
        
        if (!results || !Array.isArray(results)) {
            throw new Error('Exam results must be passed as an array!');
        }
    }

    return Course;
}

module.exports = solve;

// testing course
let course = solve().init('js oop', ['lec1', 'lec2', 'lec3', 'lec4']);
course.addStudent('Milko Kunev');
course.addStudent('Vera Dimova');
course.addStudent('Masha Genova');
course.addStudent('Ivan Peshev');
course.addStudent('Stoyan Manov');

course.submitHomework(2, 1);
course.submitHomework(2, 2);
course.submitHomework(1, 1);
course.submitHomework(3, 3);

course.pushExamResults([{StudentID: 1, score: 5}]);
course.pushExamResults([{StudentID: 2, score: 4}]);
course.pushExamResults([{StudentID: 3, score: 6}]);
course.pushExamResults([{StudentID: 4, score: 4}]);
course.pushExamResults([{StudentID: 5, score: 3}]);

course.getTopStudents();
console.log(course);