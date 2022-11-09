weight = float(input('몸무게 입력: '))
height = float(input('키 입력: '))

bmi = weight / height ** 2
print('당신의 BMI는 {0} 입니다'.format(str(bmi)))