$(function (){
    let _editModal = new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/EditModal', modalClass: 'editUser' });
    
    const queryStr = window.location.search;
    const urlParams = new URLSearchParams(queryStr);
    const userId = urlParams.get('id');
    if (userId) {
        _editModal.open({ id: userId });
    }
})