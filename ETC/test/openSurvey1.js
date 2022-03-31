function solution(b) {
  const k = b * b;
  let answer = -1;

  for (let c = b; c < k; c++) {
    for (let a = 1; a <= b; a++)
      if ((c + a) * (c - a) === k) {
        return c;
      }
  }

  return answer;
}
