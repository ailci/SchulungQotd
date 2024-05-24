$.validator.unobtrusive.adapters.addSingleVal("forbiddeninput", "blacklist");

$.validator.addMethod("forbiddeninput", function (value, element, blacklist) {
    console.log(blacklist);
    console.log(value);

    if (value) {
        const liste = blacklist.split(",");
        if ($.inArray(value.toLowerCase(), liste) !== -1) { // ungleich -1 bedeutet gefunden in der Liste
            return false;
        }
    }

    return true;
});