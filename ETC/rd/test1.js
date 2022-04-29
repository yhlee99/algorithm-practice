function getMaxDeletions(s) {
  const directionMap = new Map([
    ["U", 0],
    ["D", 0],
    ["L", 0],
    ["R", 0],
  ]);

  for (let value of s) {
    directionMap.set(value, directionMap.get(value) + 1);
  }

  const x =
    Math.abs(directionMap.get("L") + directionMap.get("R")) -
    Math.abs(directionMap.get("L") - directionMap.get("R"));
  const y =
    Math.abs(directionMap.get("U") + directionMap.get("D")) -
    Math.abs(directionMap.get("U") - directionMap.get("D"));

  return x + y;
}
