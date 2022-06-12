class Students:
    def __init__(self,name,major,age,gender):
        self.name=name
        self.major=major
        self.age=age
        self.gender=gender

    class StudentManageSystem:
        def __init__students(self,name):
            self.name=name
            self.Studentslist=[]

        def addStudent(self,name,major,age,gender):
            adds= Students(name,major,age,gender)
            self.Studentslist.append(adds)

        def removeStudent(removename):
            for i in range(students):
                    if students[i]['name'] == removename :
                        del students[i]

        def printStudentInfo(searchname):
            for j in range(students):
                    if students[j]['name'] == searchename :
                        print("-----학생 정보 출력-----")
                        print("이름 : %d" % (students[j]["name"]))
                        print("전공 : %d" % (students[j]["major"]))
                        print("나이 : %d" % (students[j]["age"]))
                        print("성별 : %d" % (students[j]["gender"]))
                        print("------------------------")
        

        def printStudentsInfo():
            for x in range(students):
                print("-----학생 정보 출력-----")
                print("이름 : %d" % (students[x]["name"]))
                print("전공 : %d" % (students[x]["major"]))
                print("나이 : %d" % (students[x]["age"]))
                print("성별 : %d" % (students[x]["gender"]))
                print("------------------------")


athlete=StudentManageSystem('운동선수')

print(athlete)

athlete.addStudent('박찬호','야구','49','M')
athlete.printStudentInfo()

athlete.addStudent('박세리','골프','48','M')
athlete.printStudentInfo()

athlete.addStudent('박지성','축구','36','M')
athlete.addStudent('김연경','배구','25','W')
athlete.addStudent('손흥민','축구','31','M')
athlete.printStudentsInfo()

athlete.removeStudent('박찬호')
athlete.removeStudent('박세리')
athlete.removeStudent('김연경')
athlete.printStudentsInfo()
