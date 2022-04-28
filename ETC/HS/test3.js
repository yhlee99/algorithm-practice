const alphabets = [
  "a",
  "b",
  "c",
  "d",
  "e",
  "f",
  "g",
  "h",
  "i",
  "j",
  "k",
  "l",
  "m",
  "n",
  "o",
  "p",
  "q",
  "r",
  "s",
  "t",
  "u",
  "v",
  "w",
  "x",
  "y",
  "z",
];

function solution(sentence) {
  const map = new Map();

  alphabets.map((a) => map.set(a, 0));

  for (let value of sentence) {
    if (map.has(value.toLowerCase())) {
      map.set(value.toLowerCase(), map.get(value.toLowerCase()) + 1);
    }
  }

  let answer = "";

  for (let [key, value] of map) {
    if (value === 0) {
      answer += key;
    }
  }

  return answer.length > 0 ? answer : "perfect";
}
