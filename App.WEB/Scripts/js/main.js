function id$(name) {
    return document.getElementById(name);
}
function class$(name) {
    return document.getElementsByClassName(name);
}


window.onload = function () {
    var menu = id$('ico-menu');
    if (menu !== null) {
        menu.addEventListener('click', Menu.Ev, true);
    }
    window.addEventListener('resize', Menu.ResizeS, true);
    window.addEventListener('resize', settings.resize, true);

    window.addEventListener('click', settings.click, true);
    if (id$('settings') !== null) {
        id$('settings').addEventListener('click', settings.event, true);

    }



}


var settings = new Object();
settings.status = false;

//изменение размера окна для меню settings
settings.resize = function () {
    if (Menu.len > innerWidth && settings.status === true && Menu.stateS === false) {
        id$('settings-menu').className = '';
        id$('settings-menu').className += 'settings-icon';
        id$('settings-menu').className += ' display-none';
        id$('arrow').className = '';
        settings.status = false;
    }
    else if (Menu.len > innerWidth && settings.status === true && Menu.stateS === true) {
        id$('settings-menu').className = '';
        id$('settings-menu').className += 'settings-icon';
        id$('settings-menu').className += ' display-block';
        id$('arrow').className += ' arrow';
        id$('settings-menu').style.top = id$('settings').getBoundingClientRect().bottom + 10 + "px";
        id$('settings-menu').style.right = (window.innerWidth - id$('settings').getBoundingClientRect().right) - 20 + "px";
        settings.status === true;
    }
    else if (Menu.len < innerWidth && settings.status === true) {
        id$('settings-menu').className = '';
        id$('settings-menu').className += 'settings-icon';
        id$('settings-menu').className += ' display-block';
        id$('arrow').className += ' arrow';
        id$('settings-menu').style.top = id$('settings').getBoundingClientRect().bottom + 10 + "px";
        id$('settings-menu').style.right = (window.innerWidth - id$('settings').getBoundingClientRect().right) - 20 + "px";
        settings.status === true;
    }
}
//функция вида меню settings
settings.statusCheng = function () {
    if (settings.status === false) {
        id$('settings-menu').className = '';
        id$('settings-menu').className += 'settings-icon';
        id$('settings-menu').className += ' display-none';
        id$('arrow').className = '';
    }
    else if (settings.status === true) {
        id$('settings-menu').className = '';
        id$('settings-menu').className += 'settings-icon';
        id$('settings-menu').className += ' display-block';
        id$('arrow').className = 'arrow';
        id$('settings-menu').style.top = id$('settings').getBoundingClientRect().bottom + 10 + "px";
        id$('settings-menu').style.right = (window.innerWidth - id$('settings').getBoundingClientRect().right) - 20 + "px";
    }
}

//вызов меню settings
settings.event = function () {
    switch (settings.status) {
        case true:
            settings.status = false;
            settings.statusCheng();
            return;
        case false:
            settings.status = true;
            settings.statusCheng();
            return;
        default:
            return;
    }
}

//нажатие не на меню settings
settings.click = function (e) {
    if (settings.status === true) {
        if (e.target.id !== 'settings-menu' && e.target.id !== 'img-sett') {
            settings.status = false;
            settings.statusCheng();
        }
    }
}



//адаптивное меню сайта
var Menu = new Object();
Menu.stateS = false;
Menu.len = 992;
Menu.ResizeS = function () {
    if (Menu.stateS === true && innerWidth > Menu.len) {
        id$('navigationid').className = '';
        id$('navigationid').className += 'navigation';
        id$('navigationid').className += ' menuClose';
    }
    else if (Menu.stateS === true && innerWidth < Menu.len) {
        id$('navigationid').className = '';
        id$('navigationid').className += 'navigation';
        id$('navigationid').className += ' menuOpen';
    }
}
Menu.Ev = function () {
    switch (Menu.stateS) {
        case true:
            id$('navigationid').className = ' ';
            id$('navigationid').className += 'navigation';
            id$('navigationid').className += ' menuClose';
            Menu.stateS = false;
            id$('settings-menu').className = '';
            id$('settings-menu').className += 'settings-icon';
            id$('settings-menu').className += ' display-none';
            id$('arrow').className = '';
            settings.status = false;
            return;
        case false:
            id$('navigationid').className = ' ';
            id$('navigationid').className += 'navigation';
            id$('navigationid').className += ' menuOpen';
            Menu.stateS = true;
            return;
        default:
            return;
    }
}
