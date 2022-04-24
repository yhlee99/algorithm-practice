function maxLength(a, k) {
  a.sort(function (a, b) {
    return a - b;
  });
  let answer = -1;

  for (let i = 0; i < a.length; i++) {
    let sum = 0;

    for (let j = 0; j < i + 1; j++) {
      sum += a[j];
    }

    if (sum > k) {
      answer = i;
      break;
    }
  }

  return answer;
}

console.log(maxLength([4, 3, 1, 2, 1], 4));
