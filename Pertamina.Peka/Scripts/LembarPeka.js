function tipefile1(){
    var ext = $("#UploadDokumenTemuan").val().split('.').pop().toLowerCase();
    if($.inArray(ext, ['gif','png','jpg','jpeg']) == -1) {
        swal(
            'Peringatan',
            'Hanya Format gif, png, jpg, jpeg yang diizinkan',
            'warning'
        );
        $("#UploadDokumenTemuan").val("");
    }
};

function Tipefile2 (){
    var ext = $("#UploadDokumenBaik").val().split('.').pop().toLowerCase();
    if($.inArray(ext, ['gif','png','jpg','jpeg']) == -1) {
        swal(
            'Peringatan',
            'Hanya Format gif, png, jpg, jpeg yang diizinkan',
            'warning'
        );
        $("#UploadDokumenBaik").val("");
    }
};


function Add() {
    var res = validate();
    if (res == false) {
        //swal(
        //    'Peringatan',
        //    'Periksa Kembali Kelengkapan isian Data Anda',
        //    'warning'
        //)
        return false;
    }

    //var today = new Date ($("#inputTanggal").val());
    //var dd = today.getDate();
    //var mm = today.getMonth()+1; 
    //var yyyy = today.getFullYear();
    //if(dd<10) {
    //    dd = '0'+dd
    //} 

    //if(mm<10) {
    //    mm = '0'+mm
    //} 
    //today = mm + '/' + dd + '/' + yyyy;
    var typesPegawai;
    var subesCategory;
    var jenisTemuans;
    var kategori;
    var tindakanPerbaikans;
    var kategoriTingkahLakuBaiks;
    var chkArray = [];
    var selected;

    //var a = $("#UploadDokumenTemuan")[0].files[0];
    //if (a != null)
    //{
    //    alert(a.name)
    //}
    //var Nama1,Nama2;
    //Nama1 = $("#UploadDokumenTemuan").val().replace(/C:\\fakepath\\/i, "");
    //Nama2 = $("#UploadDokumenBaik").val().replace(/C:\\fakepath\\/i, "");
    //alert(Nama1);
    //alert(Nama2);
    
    //var totalFiles = document.getElementById("selectedFile").files.length;
    //for (var i = 0; i < totalFiles; i++) {
    //    var file = document.getElementById("selectedFile").files[i];
    //    formData.append("FileUpload", file);
    //}


    if ($("#CheckPekerja").is(":checked")){
        typesPegawai = $("#CheckPekerja").val();
    }
    else if($("#CheckMitra").is(":checked")){
        typesPegawai = $("#CheckMitra").val();
    }
    else
    {
        typesPegawai = $("#CheckTamu").val();
    }

    if ($("#gridRadiosTingkahLaku").is(":checked")){
        jenisTemuans = $("#gridRadiosTingkahLaku").val();
    }
    else if ($("#gridRadiosKondisi").is(":checked")){
        jenisTemuans = $("#gridRadiosKondisi").val();
    }
    else if ($("#gridRadiosProcess").is(":checked")){
        jenisTemuans = $("#gridRadiosProcess").val();
    }
    else
    {
        jenisTemuans = $("#gridRadiosNonProcess").val();
    }
    
    if ($("#CheckedAPD").is(":checked")){
        kategori = $("#CheckedAPD").val();
        $('input[name="APD"]:checked').each(function() {
            chkArray.push($(this).val());
        });	
        selected = chkArray.join(',') ;

    }
    else if($("#CheckedPosisiKerja").is(":checked")){
        kategori = $("#CheckedPosisiKerja").val();
        
        $('input[name="PosisiKerja"]:checked').each(function() {
            chkArray.push($(this).val());
        });	
        selected = chkArray.join(',') ;
       
    }
    else if($("#CheckedAlatKerja").is(":checked")){
        kategori = $("#CheckedAlatKerja").val();
        $('input[name="AlatKerja"]:checked').each(function() {
            chkArray.push($(this).val());
        });	
        selected = chkArray.join(',') ;
     
    }
    else if($("#CheckedProsedur").is(":checked")){
        kategori = $("#CheckedProsedur").val();
        $('input[name="Prosedur"]:checked').each(function() {
            chkArray.push($(this).val());
        });
        
        selected = chkArray.join(',') ;
     
    }
    else if($("#CheckedLingkunganKerja").is(":checked")){
        kategori = $("#CheckedLingkunganKerja").val();
        $('input[name="LingkunganKerja"]:checked').each(function() {
            chkArray.push($(this).val());
        });	
        selected = chkArray.join(',') ;
       
    }
    else if($("#CheckedKeamanan").is(":checked"))
    {
        kategori = $("#CheckedKeamanan").val();
        $('input[name="Keamanan"]:checked').each(function() {
            chkArray.push($(this).val());
        });
     
        selected = chkArray.join(',') ;
    }
    
    if ($("#TindakLanjut").is(":checked")){
        tindakanPerbaikans = $("#TindakLanjut").val();
        
    }
    else
    {
        tindakanPerbaikans = $("#BelumTindakLanjut").val();
    }

    
    if ($("#CBaikAPD").is(":checked")){
        kategoriTingkahLakuBaiks = $("#CBaikAPD").val();
    }
    else if($("#CBaikAlatKerja").is(":checked")){
        kategoriTingkahLakuBaiks = $("#CBaikAlatKerja").val();
    }
    else if($("#CBaikPosisiKerja").is(":checked")){
        kategoriTingkahLakuBaiks = $("#CBaikPosisiKerja").val();
    }
    else if($("#CBaikProsedur").is(":checked")){
        kategoriTingkahLakuBaiks = $("#CBaikProsedur").val();
    }
    else if($("#CBaikLingkunganKerja").is(":checked")){
        kategoriTingkahLakuBaiks = $("#CBaikLingkunganKerja").val();
    }
    else if($("#CBaikKeamanan").is(":checked"))
    {
        kategoriTingkahLakuBaiks = $("#CBaikKeamanan").val();
    }

    var x = new Date();
    if ($("#CheckPekerja").is(":checked")){
        var LembarPeka = new FormData();
        //LembarPeka.append("tanggal", today);
        LembarPeka.append("nopek", $("#inputNoPekerja").val());
        LembarPeka.append("typePegawai", typesPegawai);
        LembarPeka.append("lokasi", $("#inputLokasiTemuan").val());
        LembarPeka.append("jenisTemuan", jenisTemuans);
        LembarPeka.append("kodeBagian", $("#inputBagians option:selected ").val());
        LembarPeka.append("kodeKategori", kategori);
        if ($("#CheckedAPD").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextAPD").val());
        }
        else if($("#CheckedPosisiKerja").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextPosisiKerja").val());
        }
        else if($("#CheckedAlatKerja").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextAlatKerja").val());
        }
        else if($("#CheckedProsedur").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextProsedur").val());
        }
        else if($("#CheckedLingkunganKerja").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextLingkunganKerja").val());
        }
        else if($("#CheckedKeamanan").is(":checked"))
        {
            LembarPeka.append("subKategori", selected+","+$("#TextKeamanan").val());        
        }
        LembarPeka.append("subKategori", selected);
        LembarPeka.append("deskripsi", $("#TextDeskripsi").val());
        LembarPeka.append("dokumenTemuan", $("#UploadDokumenTemuan")[0].files[0]);
        LembarPeka.append("tindakanPerbaikan", tindakanPerbaikans);
        LembarPeka.append("uraianIntervensi", $("#TextIntervensi").val());
        LembarPeka.append("saran", $("#TextSaran").val());
        LembarPeka.append("resiko", $("#txPotensial").val());
        LembarPeka.append("kategoriTingkahLakuBaik", kategoriTingkahLakuBaiks);
        LembarPeka.append("deskripsiTingkahLakuBaik", $("#deskripsiTingkahLakuBaik").val());
        LembarPeka.append("dokumenTingkahLakuBaik", $("#UploadDokumenBaik")[0].files[0]);
    }
    else{
        var LembarPeka = new FormData();
        LembarPeka.append("tanggal", today);
        if ($("#CheckMitra").is(":checked"))
        {
            LembarPeka.append("nopek", "111111");
            LembarPeka.append("idBagianPemilik", $("#inputBagian option:selected").val())
        }
        else
        {
            LembarPeka.append("nopek", "222222");
        }
        LembarPeka.append("typePegawai", typesPegawai);
        LembarPeka.append("lokasi", $("#inputLokasiTemuan").val());
        LembarPeka.append("jenisTemuan", jenisTemuans);
        LembarPeka.append("kodeBagian", $("#inputBagians option:selected").val());
        LembarPeka.append("kodeKategori", kategori);
        if ($("#CheckedAPD").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextAPD").val());
        }
        else if($("#CheckedPosisiKerja").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextPosisiKerja").val());
        }
        else if($("#CheckedAlatKerja").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextAlatKerja").val());
        }
        else if($("#CheckedProsedur").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextProsedur").val());
        }
        else if($("#CheckedLingkunganKerja").is(":checked")){
            LembarPeka.append("subKategori", selected+","+$("#TextLingkunganKerja").val());
        }
        else if($("#CheckedKeamanan").is(":checked"))
        {
            LembarPeka.append("subKategori", selected+","+$("#TextKeamanan").val());        
        }
        LembarPeka.append("subKategori", selected);
        LembarPeka.append("deskripsi", $("#TextDeskripsi").val());
        LembarPeka.append("dokumenTemuan", $("#UploadDokumenTemuan")[0].files[0]);
        LembarPeka.append("tindakanPerbaikan", tindakanPerbaikans);
        LembarPeka.append("uraianIntervensi", $("#TextIntervensi").val());
        LembarPeka.append("saran", $("#TextSaran").val());
        LembarPeka.append("resiko", $("#txPotensial").val());
        LembarPeka.append("kategoriTingkahLakuBaik", kategoriTingkahLakuBaiks);
        LembarPeka.append("deskripsiTingkahLakuBaik", $("#deskripsiTingkahLakuBaik").val());
        LembarPeka.append("dokumenTingkahLakuBaik", $("#UploadDokumenBaik")[0].files[0]);
        LembarPeka.append("namapegawai", $("#inputNama").val());
    }
    
    

    //if (LembarPeka!=null) {
    //    alert(LembarPeka.tanggal)
    //    alert(LembarPeka.dokumenTemuan.name)
    //}
    $.ajax({
        url: "/LembarPeka/Add",
        data: LembarPeka,
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        contentType: false,
        processData: false,
        beforeSend: function(){
            $.preloader.start({
                modal: true,
                src : "sprites1.png"
            });
        },
        complete: function(){
            $.preloader.stop();
        },
        success: function (result) {
            swal({
                text: "Terima kasih anda telah berpartisipasi dalam Pengamatan Keselamatan Kerja",
                type: 'success',
                showCancelButton: false,
                confirmButtonColor: '#3085d6',
  
                confirmButtonText: 'Ok'
            }).then((result) => {
                if (result.value) {
                 clearAll();       
                }
            });                 
        },
        error: function (errormessage) {
            //alert(errormessage.responseText);
            swal(
                  'Error',
                  errormessage.responseText,
                  'error'
                );
        }
    });
}

function validate() {

    var warning= [];
    var isValid = true;
    //if ($('#inputTanggal').val().trim() == "") {
    //    $('#inputTanggal').css('border-color', 'Red');
    //    isValid = false;
    //    warning.push("Tanggal")
    //}
    //else {
    //    $('#inputTanggal').css('border-color', 'lightgrey');

    //}
    if ($('#inputNama').val().trim() == "") {
        $('#inputNama').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#inputNama').css('border-color', 'lightgrey');
    }
    if ($("#inputBagians option:selected").val().trim() == "") {
        $('#inputBagians').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#inputNoPekerja').css('border-color', 'lightgrey');
    }
    if (!$("#CheckPekerja").is(":checked") && !$("#CheckMitra").is(":checked") &&  !$("#CheckTamu").is(":checked")) {
     
        isValid = false;
        warning.push("Tipe Pegawai")
    }
    if ($('#inputLokasiTemuan').val().trim() == "") {
        $('#inputLokasiTemuan').css('border-color', 'Red');
        isValid = false;
        warning.push("Lokasi Temuan")
    }
    else {
        $('#inputLokasiTemuan').css('border-color', 'lightgrey');
    }



    if (!$("#gridRadiosTingkahLaku").is(":checked")&&!$("#gridRadiosKondisi").is(":checked")&&!$("#gridRadiosProcess").is(":checked")&&!$("#gridRadiosNonProcess").is(":checked")) {
        isValid = false;
        warning.push("Jenis Temuan")
    }
    if ($("#inputBagians option:selected").val().trim() == "") {
        $('#inputBagians').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#inputBagians').css('border-color', 'lightgrey');
    }
    
    
    if (!$("#CheckedPosisiKerja").is(":checked") &&  !$("#CheckedAlatKerja").is(":checked")&& !$("#CheckedAPD").is(":checked") &&!$("#CheckedProsedur").is(":checked")&&!$("#CheckedLingkunganKerja").is(":checked")&&!$("#CheckedKeamanan").is(":checked")) {
       
        isValid = false;
        warning.push("Kategori")
    }
    if ($("#TextDeskripsi").val().trim() == "") {
        $('#TextDeskripsi').css('border-color', 'Red');
        isValid = false;
        warning.push("Deskripsi")
    }
    else {
        $('#TextDeskripsi').css('border-color', 'lightgrey');
    }
    //if ($("#UploadDokumenTemuan").val().trim() == "") {
    //    $('#UploadDokumenTemuan').css('border-color', 'Red');
    //    isValid = false;
    //    warning.push("Upload Dokumen Temuan")
    //}
    //else {
    //    $('#UploadDokumenTemuan').css('border-color', 'lightgrey');
    //}


    if (!$("#TindakLanjut").is(":checked")&&!$("#BelumTindakLanjut").is(":checked")) {
        warning.push("Tindakan Pebaikan")
        isValid = false;
    }  
    if ($("#TextIntervensi").val().trim() == "") {
        $('#TextIntervensi').css('border-color', 'Red');
        isValid = false;
        warning.push("Intervensi")
    }
    else {
        $('#TextIntervensi').css('border-color', 'lightgrey');
    }
    if ($("#TextSaran").val().trim() == "") {
        $('#TextSaran').css('border-color', 'Red');
        isValid = false;
        warning.push("Saran")
    }
    else {
        $('#TextSaran').css('border-color', 'lightgrey');
    }
    if ($("#txPotensial").val().trim() == "") {
        $('#txPotensial').css('border-color', 'Red');
        isValid = false;
        warning.push("RAM")
    }
    else {
        $('#txPotensial').css('border-color', 'lightgrey');
    }

    warning.join(",");
    
    if (warning!=null && warning != "")
    {
        swal(
                  'Peringatan',
                  'Anda Belum Memilih/Menginput '+ warning,
                  'warning'
              );  
        //alert(  'Anda Belum Memilih/Menginput '+ warning);
    }


 
    if ($("#deskripsiTingkahLakuBaik").val().trim() !== "" &&  !$("#CBaikAPD").prop("checked") && !$("#CBaikAlatKerja").prop("checked")&& !$("#CBaikProsedur").prop("checked") && !$("#CBaikPosisiKerja").prop("checked") && !$("#CBaikLingkunganKerja").prop("checked") && !$("#CBaikKeamanan").prop("checked")){
        swal(
                  'Peringatan',
                  'Kategori Tingkah Laku Baik Harus Di Isi',
                  'warning'
              );   
        isValid = false;    
           
    }

    //var inputDate = new Date ($("#inputTanggal").val());
    //var today = new Date;
    //var year = today.getYear;

    //if (inputDate > today && year < 2010)
    //{
    //    swal(
    //            'Peringatan',
    //            'Tanggal Maksimal adalah Tanggal Pada Hari ini atau Minimun Tahun yang Dipilih adalah 2010',
    //            'warning'
    //        );  
    //    $('#inputTanggal').css('border-color', 'Red');
    //    isValid = false;   
    //}


    return isValid;
}

    function clearAll() {
        location.reload()
    }