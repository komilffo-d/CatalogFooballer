const hub = new signalR.HubConnectionBuilder()
    .withUrl("/Player/Hub")
    .build();

/*$("form").on("submit", function (e) {
    hub.invoke("SendAddedUser")
        .catch(function (err) {
            console.error(err.toString());
        });
});*/

hub.on("PlayerAdd", function (playerId, player) {

    let keyName = ["name", "sex","command","country"];
    const tableBody = $(".table >  tbody").get(0);
    let tr = document.createElement("tr");
    
    keyName.forEach((k) => {
        let td = document.createElement("td");
        td.textContent = player[k];
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



hub.start();