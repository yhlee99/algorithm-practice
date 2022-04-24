function findRange(num) {
  return Number(getMaxNumber(num)) - Number(getMinNumber(num));
}

function getMaxNumber(num) {
  let numString = num.toString();
  let maxNumber = "";

  for (let i = 0; i < numString.length; i++) {
    if (numString[i] !== "9") {
      maxNumber = numString[i];
      break;
    }
  }

  return maxNumber ? replaceAll(numString, maxNumber, "9") : numString;
}

function getMinNumber(num) {
  let numString = num.toString();
  let minNumber = "";
  let replaceNumber = "";

  if (numString[0] !== "1") {
    minNumber = numString[0];
    replaceNumber = "1";
  } else {
    for (let i = 1; i < numString.length; i++) {
      if (numString[i] !== "0") {
        if (numString[i] === "1" && numString[i] === numString[0]) {
          continue;
        } else {
          minNumber = numString[i];
          replaceNumber = "0";
          break;
        }
      }
    }
  }

  return minNumber
    ? replaceAll(numString, minNumber, replaceNumber)
    : numString;
}

function replaceAll(str, searchStr, replaceStr) {
  return str.split(searchStr).join(replaceStr);
}
