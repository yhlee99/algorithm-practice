function solution(number, k) {
  let fixedIndex = 0;
  let numberArray = Array.from(number, Number);
  let resultNumber = [];

  while (k > 0) {
    const max = Math.max(...numberArray.slice(fixedIndex, fixedIndex + k + 1)); // 9
    const maxIndex = numberArray.indexOf(max); // 1

    resultNumber.push(max);
    numberArray = numberArray.slice(maxIndex + 1, number.length);
    k -= maxIndex - fixedIndex;
    fixedIndex = maxIndex + 1;
    console.log(fixedIndex);
    k = -1;
  }

  console.log(...resultNumber);

  // return resultNumber.map(String);
}

console.log(solution("1924", 2));
