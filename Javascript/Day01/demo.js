// first task
for (var i = 1; i <= 6; i++)
  document.write(`<h${i}>This is header number ${i}</h${i}>`);

// seconds task
// var sum = 0;
// do {
//   var n = prompt("enter values");
//   if (!isNaN(parseInt(n))) sum += parseInt(n);
// } while (sum <= 100 && parseInt(n) !== 0);
// console.log(sum);

// third task
function showEvenorOdd(arr, choice) {
  if (choice === 1) {
    for (var i = 0; i < arr.length; i++) {
      if (arr[i] % 2 !== 0)
        console.log(`%c${arr[i]}`, "color:red;font-size:30px;");
    }
  } else {
    for (var i = 0; i < arr.length; i++) {
      if (arr[i] % 2 === 0)
        console.log(`%c${arr[i]}`, "color:green;font-size:30px;");
    }
  }
}
var firstNum, secondNum, choice;
var range = [];
do {
  firstNum = prompt("enter first number");
  firstNum = parseInt(firstNum);
} while (isNaN(parseInt(firstNum)));
do {
  secondNum = prompt("enter Second number");
  secondNum = parseInt(secondNum);
} while (isNaN(parseInt(secondNum)));

if (firstNum > secondNum) {
  for (var i = 0; i <= firstNum - secondNum; i++) {
    range[i] = secondNum + i;
  }
} else {
  for (var i = 0; i <= secondNum - firstNum; i++) {
    range[i] = secondNum + i;
  }
}

for (var i = 0; i < range.length; i++) {
  console.log(range[i]);
}

do {
  choice = prompt("Enter 1 for displaying odd numbers, 2 for displaying even");
  choice = parseInt(choice);
} while (isNaN(parseInt(choice)));

showEvenorOdd(range, choice);
