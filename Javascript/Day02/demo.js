// task 1.1
// var str = prompt("Enter a string");
// var char = prompt("enter a char");
// var choice;
// do {
//   choice = parseInt(
//     prompt(
//       "Do you consider difference between letter cases or not? (1. yes - 0. No)"
//     )
//   );
// } while (choice < 0 || choice > 1);
// var regExp = new RegExp(char, choice == 0 ? "gi" : "g");
// console.log(str.match(regExp).length);

// task 1.2
// function isPlaindrome(str) {
//   for (var i = 0, j = str.length - 1; j > i; i++, j--) {
//     if (str[i] != str[j]) return false;
//   }
//   return true;
// }
// var str = prompt("enter a string to check if it's a palindrom or not");
// var choice;
// do {
//   choice = parseInt(
//     prompt(
//       "Do you consider difference between letter cases or not? (1. yes - 0. No)"
//     )
//   );
// } while (choice < 0 || choice > 1);
// if (choice) {
//   if (isPlaindrome(str)) console.log(str + " is palindrome");
//   else console.log(str + " is not palindrome");
// } else {
//   if (isPlaindrome(str.toLowerCase())) console.log(str + " is palindrome");
//   else console.log(str + " is not palindrome");
// }

// // Task 1.3
// function biggestWord(str) {
//   var strArr = str.split(" ");
//   var biggestLength = 0;
//   var biggestWord;
//   for (var i = 0; i < strArr.length; i++) {
//     if (strArr[i].length > biggestLength) {
//       biggestLength = strArr[i].length;
//       biggestWord = strArr[i];
//     }
//   }
//   return biggestWord;
// }

// console.log(biggestWord("this is a javascript  javascripts string demo"));

// // Task 1.4
// var userName, phoneNum, mobNum, Email, colorChoice;
// do {
//   userName = prompt("Enter your name");
// } while (userName.match(/[A-Z]\w+/gi) === null);

// do {
//   phoneNum = prompt("Enter phone number (length=8)");
// } while (phoneNum.match(/^[0-9]{8}$/g) === null);

// do {
//   mobNum = prompt(
//     "Enter phone number (length=11 starting with (010 or 011 or 012 or 015))"
//   );
// } while (mobNum.match(/^(010|011|015|012)[0-9]{8}$/) === null);

// do {
//   Email = prompt("Enter your email xxxxxx@xxxxx.(xx)or(xxx)");
// } while (Email.match(/[a-z0-9]+@[a-z]+\.[a-z]{2,3}/) === null);

// do {
//   colorChoice = parseInt(prompt("Enter 1- red, 2- green, 3- blue"));
// } while (colorChoice < 0 || colorChoice > 3);

// switch (colorChoice) {
//   case 1:
//     document.write(`<p style="color:red">Welcome dear guest ${userName}</p>`);
//     document.write(
//       `<p style="color:red">Your Telephone number is  ${phoneNum}</p>`
//     );
//     document.write(`<p style="color:red">Your Mobile number is  ${mobNum}</p>`);
//     document.write(`<p style="color:red">Your Email address is  ${Email}</p>`);
//     document.write(`<p style="color:red">Today is  ${new Date()}</p>`);
//     break;
//   case 2:
//     document.write(`<p style="color:green">Welcome dear guest ${userName}</p>`);
//     document.write(
//       `<p style="color:green">Your Telephone number is  ${phoneNum}</p>`
//     );
//     document.write(
//       `<p style="color:green">Your Mobile number is  ${mobNum}</p>`
//     );
//     document.write(
//       `<p style="color:green">Your Email address is  ${Email}</p>`
//     );
//     document.write(`<p style="color:green">Today is  ${new Date()}</p>`);
//     break;
//   case 3:
//     document.write(`<p style="color:blue">Welcome dear guest ${userName}</p>`);
//     document.write(
//       `<p style="color:blue">Your Telephone number is  ${phoneNum}</p>`
//     );
//     document.write(
//       `<p style="color:blue">Your Mobile number is  ${mobNum}</p>`
//     );
//     document.write(`<p style="color:blue">Your Email address is  ${Email}</p>`);
//     document.write(`<p style="color:blue">Today is  ${new Date()}</p>`);
//     break;
//   default:
//     document.write(`<p>Welcome dear guest ${userName}</p>`);
//     document.write(`<p >Your Telephone number is  ${phoneNum}</p>`);
//     document.write(`<p>Your Mobile number is  ${mobNum}</p>`);
//     document.write(`<p>Your Email address is  ${Email}</p>`);
//     document.write(`<p>Today is  ${new Date()}</p>`);
//     break;
// }

// // Task 2.1
// function dispVal(obj, key) {
//   return obj[key];
// }

// var objectp = {
//   nm: "ali",
//   age: 10,
// };
// console.log(dispVal(objectp, "age"));

// // task 3
// var arr = [];
// for (var i = 1; i <= 5; i++) {
//   do {
//     arr[i - 1] = parseInt(prompt("enter " + i + " element"));
//   } while (isNaN(arr[i - 1]));
// }
// document.write(
//   "<p style='color:red'>You entered " +
//     arr[0] +
//     "," +
//     arr[1] +
//     "," +
//     arr[2] +
//     "," +
//     arr[3] +
//     "," +
//     arr[4] +
//     "</p>"
// );
// arr.sort((a, b) => a - b);
// document.write(
//   "<p style='color:red'>Your values after being sorted descendingly " +
//     arr[0] +
//     "," +
//     arr[1] +
//     "," +
//     arr[2] +
//     "," +
//     arr[3] +
//     "," +
//     arr[4] +
//     "</p>"
// );
// arr.sort((a, b) => b - a);
// document.write(
//   "<p style='color:red'>Your values after being sorted ascendingly " +
//     arr[0] +
//     "," +
//     arr[1] +
//     "," +
//     arr[2] +
//     "," +
//     arr[3] +
//     "," +
//     arr[4] +
//     "</p>"
// );

// // task 4
var radius;
do {
  radius = parseInt(prompt("enter circle radius to calculate its area"));
} while (isNaN(radius));
confirm("Area of the circle is " + Math.PI * radius * radius);

var num;
do {
  num = parseInt(prompt("enter a number to get its square root"));
} while (isNaN(num));
confirm("Square root of " + num + " is " + Math.sqrt(num));

var angle;
do {
  angle = parseInt(prompt("enter an angle to get its cosine"));
} while (isNaN(angle));
var Pi = Math.PI;
confirm("cos(" + angle + ") is " + Math.cos((angle / 180) * Pi).toFixed());
