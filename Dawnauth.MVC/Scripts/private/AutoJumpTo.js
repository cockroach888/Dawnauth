var duration = 1E4, endTime = (new Date).getTime() + duration + 100; function interval() { var a = (endTime - (new Date).getTime()) / 1E3; if (!(0 > a)) document.getElementById("timeout").innerHTML = a.toFixed(0), setTimeout(interval, 100) } window.onload = function () { setTimeout("window.location.href='/Dawnauth/Desktop/'", duration); interval() };