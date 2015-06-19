$(function () {

    // Hook up Class watch operation and toggle hidden (uses jquery-watch.js)
    $("span[class*=\"field-validation-\"]").watch({
        properties: "attr_class",
        callback: function () {
            $(this).parent("div.index-valid").toggleClass("hidden");
        }
    });

});