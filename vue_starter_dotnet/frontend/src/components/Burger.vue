<template>
  <div id="burger" :class="{ 'active' : isBurgerActive }" @click.prevent="toggle">
    <slot>
      <button type="button" class="burger-button" title="Menu">
        <font-awesome-icon icon="bars" style="color: black" size="3x" />
      </button>
    </slot>
  </div>
</template>

<script>
 import { store, mutations } from "@/store.js";
 import {FontAwesomeIcon} from "@fortawesome/vue-fontawesome";

export default {
    components: {
        FontAwesomeIcon
    },
    computed: {
        isBurgerActive() {
            return store.isNavOpen;
        }
    },
/*   data() {
      return {
          isBurgerActive: false
      }
  }, */
  methods: {
    toggle() {
    //  this.isBurgerActive =! this.isBurgerActive;
      mutations.toggleNav();
    }
  }
};
</script>
<style>
.hidden {
  visibility: hidden;
}

button {
  cursor: pointer;
}

/* remove blue outline */
button:focus {
  outline: 0;
}

.burger-button {
  position: relative;
  height: 30px;
  width: 32px;
  display: block;
  z-index: 999;
  border: 0;
  border-radius: 0;
  background-color: transparent;
  pointer-events: all;
}

.burger-bar {
  background-color: black;
  position: absolute;
  top: 50%;
  right: 6px;
  left: 6px;
  height: 2px;
  width: auto;
  margin-top: -1px;
}

</style>