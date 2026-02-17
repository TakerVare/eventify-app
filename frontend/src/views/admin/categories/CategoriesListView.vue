<!--
  =============================================================================
  ADMIN CATEGORIES LIST VIEW - Lista de categorías (Administración)
  =============================================================================
  Vista de administración que muestra todas las categorías de eventos.
  =============================================================================
-->

<script setup lang="ts">
import { computed, onMounted } from 'vue'
import { useCategoriesStore } from '@/stores/categories'

const categoriesStore = useCategoriesStore()

const loading = computed(() => categoriesStore.loading)

const headers = [
  { title: 'Nombre', key: 'name', sortable: true },
  { title: 'Descripción', key: 'description', sortable: false },
  { title: 'Icono', key: 'icon', sortable: false, align: 'center' },
  { title: 'Color', key: 'color', sortable: false, align: 'center' }
]

onMounted(async () => {
  await categoriesStore.fetchCategories()
})
</script>

<template>
  <div class="admin-categories-list-view">
    <div class="mb-6">
      <h1 class="text-h4 font-weight-bold mb-2">
        Gestión de Categorías
      </h1>
      <p class="text-body-1 text-medium-emphasis">
        Categorías disponibles para clasificar eventos
      </p>
    </div>

    <v-card>
      <v-data-table
        :headers="headers"
        :items="categoriesStore.categories"
        :loading="loading"
        class="elevation-1"
      >
        <template #item.name="{ item }">
          <div class="d-flex align-center ga-2">
            <v-chip
              :color="item.color"
              size="small"
              :prepend-icon="item.icon"
            >
              {{ item.name }}
            </v-chip>
          </div>
        </template>

        <template #item.description="{ item }">
          <span class="text-body-2 text-medium-emphasis">
            {{ item.description || '—' }}
          </span>
        </template>

        <template #item.icon="{ item }">
          <v-icon :color="item.color">{{ item.icon }}</v-icon>
        </template>

        <template #item.color="{ item }">
          <v-tooltip :text="item.color">
            <template #activator="{ props }">
              <v-sheet
                v-bind="props"
                :color="item.color"
                width="24"
                height="24"
                rounded
              />
            </template>
          </v-tooltip>
        </template>
      </v-data-table>
    </v-card>
  </div>
</template>

<style scoped lang="scss">
.admin-categories-list-view {
  // Estilos si son necesarios
}
</style>
