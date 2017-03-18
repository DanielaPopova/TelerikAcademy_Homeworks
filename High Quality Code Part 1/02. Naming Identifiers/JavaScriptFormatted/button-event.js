function buttonClick(event, parameters) {
    let thisWindow = window,
        browserName = thisWindow.navigator.appCodeName,
        isMozilla = browserName == "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}