function solution(prices) {
  const answer = [];
  let priceIndex = 0;

  while (priceIndex < prices.length) {
    let value = prices[priceIndex];
    priceIndex++;

    let count = 0;

    for (let i = priceIndex; i < prices.length; i++) {
      count++;

      if (value > prices[i]) {
        break;
      }
    }

    answer.push(count);
  }

  return answer;
}

console.log(solution([1, 2, 3, 2, 3]));
