// 1, 1 + 1, 1, min(a3 + 1), min(a2 + 3, a4 + 1), min(a3 + 3, a5 + 1)
// list 안 같은 값 있는 지? 있으면 그거쓰고
// min(a[k - 1] + 1, a[k - 3] + 3, a[k - 5] + 5);

function solution(n, target, coins) {
  let table = [0];

  for (let i = 1; i <= target; i++) {
    if (coins.includes(i)) {
      table.push(1);
    } else {
      const candidates = [];
      for (let j = 0; j < n; j++) {
        if (i - coins[j] > 0 && table[i - coins[j]] !== -1) {
          candidates.push(table[i - coins[j]] + 1);
        }
      }
      if (candidates.length > 0) {
        table.push(Math.min(...candidates));
      } else {
        table.push(-1);
      }
    }
  }

  return table.pop();
}

console.log(solution(3, 4, [3, 5, 7]));
