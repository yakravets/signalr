let tg = window.Telegram.WebApp;

tg.expand();

tg.MainButton.textColor = "#FFFFFF";
tg.MainButton.color = "#2cab37";

let item = "";

function onClickAdd(product_id) {

    let btn_add_name = `btnadd${product_id}`;
    let badge_name = `badge${product_id}`;
    let btn_rm_name = `btnrm${product_id}`;

    let badge = document.getElementById(badge_name);

    const count = parseInt(badge.innerText);
    if (isNaN(count) || count == 0) {
        badge.innerText = 1;
        badge.classList.remove("hidden");
        badge.classList.add("visibility");

        let btn = document.getElementById(btn_add_name);
        btn.innerText = '+';

        let btn_rm = document.getElementById(btn_rm_name);
        btn_rm.classList.remove("display-none");
        btn_rm.classList.add("display-inline-block");

    }
    else {
        badge.innerText = count + 1;
    }

    if (tg.MainButton.isVisible) {
        tg.MainButton.hide();
    }
    else {
        tg.MainButton.setText(`Вы выбрали товар ${product_id}!`);
        item = toString(this.product_id);
        tg.MainButton.show();
    }
}

function onClickRm(product_id) {
    let btn_add_name = `btnadd${product_id}`;
    let badge_name = `badge${product_id}`;
    let btn_rm_name = `btnrm${product_id}`;

    let badge = document.getElementById(badge_name);

    const count = parseInt(badge.innerText);
    badge.innerText = count - 1;
    if (count == 1) {
        badge.classList.remove("visibility");
        badge.classList.add("hidden");

        let btn = document.getElementById(btn_add_name);
        btn.innerText = 'ADD';

        let btn_rm = document.getElementById(btn_rm_name);
        btn_rm.classList.remove("display-inline-block");
        btn_rm.classList.add("display-none");

        if (tg.MainButton.isVisible) {
            tg.MainButton.hide();
        }
    }
}


Telegram.WebApp.onEvent("mainButtonClicked", function () {
    tg.sendData(item);
    tg.BackButton.show();
});

let usercard = document.getElementById("usercard");

let p = document.createElement("p");

p.innerText = `${tg.initDataUnsafe.user.first_name} ${tg.initDataUnsafe.user.last_name}`;

usercard.appendChild(p); 