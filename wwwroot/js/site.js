const hub = new signalR.HubConnectionBuilder()
    .withUrl("/Player/Hub")
    .build();

function isDate(date) {
    return date && (new Date(date) !== "Invalid Date") && !isNaN(new Date(date));
}
hub.on("PlayerAdd", function (playerId, player) {

    let keyName = ["name", "sex", "dateBirthday","command", "country",];
    const tableBody = $(".table >  tbody").get(0);
    let tr = document.createElement("tr");
    
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
    let a = document.createElement("a");
    a.textContent = "Edit";
    a.href = `/Player/Edit/${playerId}`;
    td.appendChild(a);
    tr.appendChild(td);


    tableBody.appendChild(tr);


});

hub.on("PlayerModify", function (playerId, player) {

    let keyName = ["name", "sex", "dateBirthday","command", "country", ];
    const tableBody = $(".table >  tbody").get(0);
    let tr = $(tableBody).find(`[data-player=${playerId}]`).empty().get(0);

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
    let a = document.createElement("a");
    a.textContent = "Edit";
    a.href = `/Player/Edit/${playerId}`;
    td.appendChild(a);
    tr.appendChild(td);


});

hub.start();