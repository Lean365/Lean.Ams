function radomNo() {
  return getAmsNum() + Math.floor(Math.random() + 10000)
}

function getAmsNum() {

  const amsTime = new Date()
  const Year = amsTime.getFullYear()
  const Month = amsTime.getMonth()
  const Day = amsTime.getDay()
  var currentDate = Year
  if (Month >= 10) {
    currentDate += Month
  } else {
    currentDate += '0' + Month
  }
  if (Day >= 10) {
    currentDate += Day
  } else {
    currentDate += '0' + Day
  }
  return currentDate
}
export default {
  radomNo
}