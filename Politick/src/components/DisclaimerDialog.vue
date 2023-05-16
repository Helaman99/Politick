<template>
    <div class = 'disclaimer'>

        <v-dialog value = 'disclaimer'>
            <v-card width = '50%' class = 'disclaimer-card'>
                <v-card-title><h2>DISCLAIMER</h2></v-card-title>
                <v-card-text>
                    Interactions in these chatrooms may not be appropriate for all ages.
                    We do everything we can to filter out inappropriate or offensive language. 
                    However, we are not perfect and can't catch everything. By participating
                    in this game, you may encounter things that are offensive. If this happens,
                    <i>please</i> let us know at [contact info].
                </v-card-text>
                <v-card-actions>
                    <v-btn elevation = '1'>I Understand</v-btn>
                    <v-btn elevation = '1' @click = 'disclaimer = false'>Go Back</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>

    </div>
</template>

<script>
export default {
    props: { disclaimer: Boolean }
}
</script>

<style scoped>
.disclaimer-card {
    text-align: center;
    padding: 1%;
}
</style>
