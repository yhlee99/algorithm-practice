const targetWord = "AWS";

function getFinalString(s) {
  while (s.includes(targetWord)) {
    s = s.replace(targetWord, "");
  }

  return s.length > 0 ? s : -1;
}

getFinalString("AWAWSSG");
