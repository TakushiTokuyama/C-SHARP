// 全件更新処理
function alledit() {
    console.log('alledit');
    document.allUpdate.submit();
}

// 更新処理
function edit() {
    console.log('edit');
    document.update.submit();
}

// ドロップダウンリストで更新
function dropedit() {
    console.log('dropDwonListUpdate');
    document.kbn.submit();
}

// 在庫の名前で更新
function zaikoedit(){
    console.log('zaikoedit');

    var product = document.getElementById('product');

    product.appendChild(product.innerHTML);

    document.zaikoUpdate.submit();
}