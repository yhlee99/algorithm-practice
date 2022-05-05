function solution(a) {
  let answer = 45;

  for (let value of a) {
    answer -= value;
  }

  return answer;
}

a([0, 1, 2, 3, 4, 5, 7, 8, 9]);
