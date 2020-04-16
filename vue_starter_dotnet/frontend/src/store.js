import Vue from "vue";

export const store = Vue.observable({
    isNavOpen: false
});
//export default {};
export const mutations = {
/*     setIsNavOpen(yesno) {
        store.isNavOpen = yesno;
    }, */
    toggleNav() {
        store.isNavOpen = !store.isNavOpen;
    }
};