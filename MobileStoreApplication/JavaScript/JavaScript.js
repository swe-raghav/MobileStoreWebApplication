function BrandFunction() {
    document.getElementById("BrandDropdown").classList.toggle("show");

}

function PriceFunction() {
    document.getElementById("PriceDropdown").classList.toggle("show");
}

function FeatureFunction() {
    document.getElementById("FeatureDropdown").classList.toggle("show");
}
function FeatureFunction1() {
    document.getElementById("FeatureDropdown1").classList.toggle("show");
}

function BrandfilterFunction() {
    var input, filter, ul, li, a, i;
    input = document.getElementById("MyInput");
    filter = input.value.toUpperCase();
    d = document.getElementById("BrandDropdown");
    a = d.getElementsByTagName("a");
    for (i = 0; i < a.length; i++) {
        txtValue = a[i].textContent || a[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            a[i].style.display = "";
        } else {
            a[i].style.display = "none";
        }
    }
}


function  FeaturefilterFunction() {
    //var input, filter, ul, li, a, i;
    //search = document.getElementById("btn").value;
    search = document.getElementById("btn").value;
    

   // document.getElementById("demo").innerHTML = search;
    //filter = input.value.toUpperCase();
    //d = document.getElementById("FeatureDropdown");
    //a = d.getElementsByTagName("a");
    //for (i = 0; i < a.length; i++) {
    //    txtValue = a[i].textContent || a[i].innerText;
    //    if (txtValue.toUpperCase().indexOf(filter) > -1) {
    //        a[i].style.display = "";
    //    } else {
    //        a[i].style.display = "none";
    //    }
    //}
}