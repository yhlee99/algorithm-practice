class Node {
  constructor(depth) {
    this.type = "";
    this.depth = depth;
    this.nodes = [];
  }

  setType(type) {
    this.type = type;

    if (type === "p") {
      for (let i = 0; i < 4; i++) {
        const node = new Node(this.depth + 1);
        this.nodes.push(node);
        nodeStack.push(node);
      }
    }
  }
}

let nodeStack = []; // 아직 안채워져 들어가야할 Node

function solution(s1, s2) {
  // Make s1 Node Tree
  const array1 = s1.split("");
  const rootNode1 = new Node(0);
  nodeStack.push(rootNode1);
  let index = 0;

  while (nodeStack.length > 0) {
    const targetNode = nodeStack.pop();
    targetNode.setType(array1[index]);
    index++;
  }

  // Init
  nodeStack = [];
  index = 0;

  // Make s2 Node Tree
  const array2 = s2.split("");
  const rootNode2 = new Node(0);
  nodeStack.push(rootNode2);

  while (nodeStack.length > 0) {
    const targetNode = nodeStack.pop();
    targetNode.setType(array2[index]);
    index++;
  }

  var answer = 0;
  return answer;
}

solution("ddsadsa", "pdsadsa");
