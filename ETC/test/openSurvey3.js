function solution(n) {
  let numbers = [0]; // 3의 0제곱
  let index = 0;

  Loop1: while (true) {
    const baseNumber = 3 ** index;
    const length = numbers.length;

    for (let i = 0; i < length; i++) {
      numbers.push(baseNumber + numbers[i]);

      if (numbers.length > n) {
        break Loop1;
      }
    }

    index++;
  }

  return numbers[n];
}
