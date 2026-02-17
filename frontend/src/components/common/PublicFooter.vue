<!--
  =============================================================================
  PUBLIC FOOTER - Footer para vistas públicas
  =============================================================================
  Componente de pie de página para las páginas públicas de la aplicación.

  Incluye:
  - Información de la empresa
  - Enlaces útiles
  - Redes sociales
  - Copyright
  =============================================================================
-->

<script setup lang="ts">
import { useI18n } from 'vue-i18n'

const { t } = useI18n()

const currentYear = new Date().getFullYear()

// Enlaces de navegación del footer
const footerLinks = [
  {
    title: 'Empresa',
    links: [
      { text: 'Sobre nosotros', href: '#' },
      { text: 'Equipo', href: '#' },
      { text: 'Carreras', href: '#' },
      { text: 'Blog', href: '#' }
    ]
  },
  {
    title: 'Soporte',
    links: [
      { text: 'Centro de ayuda', href: '#' },
      { text: 'FAQ', href: '#' },
      { text: t('footer.contact'), href: '#' },
      { text: 'Estado del servicio', href: '#' }
    ]
  },
  {
    title: 'Legal',
    links: [
      { text: t('footer.privacyPolicy'), href: '#' },
      { text: t('footer.termsOfService'), href: '#' },
      { text: 'Política de cookies', href: '#' },
      { text: 'Accesibilidad', href: '#' }
    ]
  }
]

// Redes sociales
const socialLinks = [
  { icon: 'mdi-facebook', href: '#', label: 'Facebook' },
  { icon: 'mdi-twitter', href: '#', label: 'Twitter' },
  { icon: 'mdi-instagram', href: '#', label: 'Instagram' },
  { icon: 'mdi-linkedin', href: '#', label: 'LinkedIn' }
]
</script>

<template>
  <v-footer
    class="public-footer bg-surface"
    elevation="8"
  >
    <v-container class="public-footer__container">
      <!-- Contenido principal del footer -->
      <v-row class="public-footer__row">
        <!-- Columna 1: Información de la empresa -->
        <v-col
          cols="12"
          md="4"
          class="public-footer__brand mb-4 mb-sm-4 mb-md-0"
        >
          <!-- Logo y descripción -->
          <div class="d-flex align-center mb-3 mb-sm-4">
            <v-icon size="32" color="primary" class="public-footer__logo-icon mr-2">mdi-calendar-star</v-icon>
            <span class="text-h6 font-weight-bold text-primary">Eventify</span>
          </div>

          <p class="public-footer__description text-body-2 text-medium-emphasis mb-3 mb-sm-4">
            La plataforma líder para la gestión y organización de eventos.
            Conectamos organizadores con asistentes de manera simple y efectiva.
          </p>

          <!-- Redes sociales -->
          <div class="d-flex flex-wrap ga-2">
            <v-btn
              v-for="social in socialLinks"
              :key="social.label"
              :icon="social.icon"
              :href="social.href"
              variant="text"
              size="small"
              :aria-label="social.label"
              class="public-footer__social-btn"
            />
          </div>
        </v-col>

        <!-- Columnas 2-4: Enlaces -->
        <v-col
          v-for="(section, index) in footerLinks"
          :key="section.title"
          cols="6"
          sm="4"
          md="2"
          :class="{ 'offset-md-1': index === 0 }"
          class="public-footer__links-col"
        >
          <h3 class="text-subtitle-2 text-sm-subtitle-1 font-weight-bold mb-2 mb-sm-3">
            {{ section.title }}
          </h3>

          <v-list density="compact" class="bg-transparent public-footer__list">
            <v-list-item
              v-for="link in section.links"
              :key="link.text"
              :href="link.href"
              class="px-0 min-h-auto py-1"
              min-height="auto"
            >
              <v-list-item-title class="text-caption text-sm-body-2">
                {{ link.text }}
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-col>
      </v-row>

      <v-divider class="public-footer__divider my-3 my-sm-4" />

      <!-- Copyright y enlaces legales -->
      <v-row>
        <v-col cols="12" class="public-footer__copyright text-center text-md-start">
          <p class="text-caption text-medium-emphasis mb-0">
            {{ t('footer.copyright', { year: currentYear }) }}
          </p>
        </v-col>
      </v-row>
    </v-container>
  </v-footer>
</template>

<style scoped lang="scss">
.public-footer {
  padding-top: 1rem;
  padding-bottom: 1rem;

  @media (min-width: 600px) {
    padding-top: 1.25rem;
    padding-bottom: 1.25rem;
  }

  @media (min-width: 960px) {
    padding-top: 1.5rem;
    padding-bottom: 1.5rem;
  }
}

.public-footer__container {
  padding-left: 1rem;
  padding-right: 1rem;
  max-width: 100%;

  @media (min-width: 600px) {
    padding-left: 1.5rem;
    padding-right: 1.5rem;
  }

  @media (min-width: 960px) {
    padding-left: 24px;
    padding-right: 24px;
  }
}

.public-footer__description {
  max-width: 100%;

  @media (min-width: 960px) {
    max-width: 320px;
  }
}

.public-footer__links-col {
  margin-bottom: 0.5rem;

  @media (min-width: 600px) {
    margin-bottom: 0;
  }
}

.public-footer__list :deep(.v-list-item) {
  min-height: 28px;

  @media (min-width: 600px) {
    min-height: 32px;
  }
}

.public-footer__logo-icon {
  flex-shrink: 0;
  @media (max-width: 599px) {
    font-size: 28px !important;
  }
}

.public-footer__social-btn {
  min-width: 36px;
}

.public-footer__divider {
  margin-left: -1rem;
  margin-right: -1rem;
  max-width: 100vw;

  @media (min-width: 600px) {
    margin-left: -1.5rem;
    margin-right: -1.5rem;
  }

  @media (min-width: 960px) {
    margin-left: 0;
    margin-right: 0;
  }
}

.public-footer__copyright p {
  word-break: break-word;
  line-height: 1.4;
}
</style>
