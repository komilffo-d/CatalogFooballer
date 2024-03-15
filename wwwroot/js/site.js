const hub = new signalR.HubConnectionBuilder()
    .withUrl("/Player/Hub")
    .build();

function isDate(date) {
    return date && (new Date(date) !== "Invalid Date") && !isNaN(new Date(date));
}
hub.on("PlayerAdd", function (playerId, player) {

    let keyName = ["surname","name", "sex", "dateBirthday","command", "country",];
    const tableBody = $(".table >  tbody").get(0);
    let tr = document.createElement("tr");
    tr.setAttribute("data-player", playerId.toString());
    tr.classList.add("table-row");

    keyName.forEach((k) => {
        let td = document.createElement("td");
        switch (k) {
            case "dateBirthday":
                td.textContent = isDate(player[k]) ? new Intl.DateTimeFormat("ru", { dateStyle: "long" }).format(new Date(player[k])).toString() : "Отсутствуют данные о дате рождения!";
                break;
            default:
                td.textContent = player[k];
                break;
        }


        tr.appendChild(td);
    });

    let td = document.createElement("td");
    td.innerHTML = `
        <div class="table-row__edit">
            <div class="table-row__edit__image">
                <img src="/images/vectors/pen_edit.svg" width="30">
            </div>
            <a class="table-row__edit__link" href="/Player/Edit/${playerId}">Редактировать игрока</a>
        </div>
    `;
    tr.appendChild(td);

    tableBody.appendChild(tr);


});

hub.on("PlayerModify", function (playerId, player) {

    let keyName = ["surname", "name", "sex", "dateBirthday","command", "country", ];
    const tableBody = $(".table >  tbody").get(0);
    let tr = $(tableBody).find(`.table-row[data-player=${playerId}]`).empty().get(0);

    keyName.forEach((k) => {
        let td = document.createElement("td");
        switch (k) {
            case "dateBirthday":
                td.textContent = isDate(player[k]) ? new Intl.DateTimeFormat("ru", { dateStyle: "long" }).format(new Date(player[k])).toString() : "Отсутствуют данные о дате рождения!";
                break;
            default:
                td.textContent = player[k];
                break;
        }

        
        tr.appendChild(td);
    });

    let td = document.createElement("td");
    td.innerHTML = `
        <div class="table-row__edit">
            <div class="table-row__edit__image">
                <img src="/images/vectors/pen_edit.svg" width="30">
            </div>
            <a class="table-row__edit__link" href="/Player/Edit/${playerId}">Редактировать игрока</a>
        </div>
    `;
    tr.appendChild(td);


});

hub.start();