function solution(n) {
  let targetCount = findNumberOneCount(n.toString(2));
  let answer = 0;

  for (let i = 1; i < n; i++) {
    if (targetCount === findNumberOneCount(i.toString(2))) {
      answer++;
    }
  }

  return answer;
}

function findNumberOneCount(s) {
  let count = 0;

  for (let v of s) {
    if (v === "1") {
      count++;
    }
  }

  return count;
}
