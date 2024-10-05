function readJsonFile(file) {
    const request = new XMLHttpRequest();
    request.open('GET', file, false);
    request.send(null);
    var json = JSON.parse(request.responseText);
    
    Object.keys(json).forEach(function (key) {
        console.log(`Id : ${json[key].CategoryId}, Value : ${json[key].CategoryName}`);
    });

}