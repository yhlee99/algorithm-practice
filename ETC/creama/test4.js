function replaceAt(index, replacement) {
  return (
    this.substr(0, index) +
    replacement +
    this.substr(index + replacement.length)
  );
}

function longestChain(words) {}

function calculateChain(words) {
  let word = words[0];
  word = "hello";
  for (let i = 0; i < word.lenth; i++) {
    return word.replaceAt(i, "s");
  }
}

console.log(calculateChain(["hello"]));
