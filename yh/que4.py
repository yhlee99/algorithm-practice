class Coffee:
  def __init__(self, name, price):
    self.name = name
    self.price = price
    self.count = 0

coffee_list = [Coffee('에스프레소', 2500), Coffee('아메리카노', 2500), Coffee('카페라떼', 3000)]
total_price = 0

for coffee in coffee_list:
  coffee.count = int(input('{0}의 수를 입력하세요: '.format(coffee.name)))
  total_price += coffee.price * coffee.count

print('총 금액은 {0}입니다.'.format(total_price))