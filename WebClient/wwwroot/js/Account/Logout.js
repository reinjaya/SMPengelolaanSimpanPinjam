function logoutAccount() {
    sessionStorage.removeItem('idUser');
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('role');
    sessionStorage.removeItem('nama');

    window.location.replace("../Login");
}